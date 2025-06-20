﻿using LojaVirtual.Core.Business.Entities;
using LojaVirtual.Core.Infra.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LojaVirtual.Core.Infra.Seed
{
    public static class DbMigrationHelperExtension
    {
        public static void UseDbMigrationHelper(this WebApplication app)
        {
            DbMigrationHelper.EnsureSeedData(app).Wait();
        }
    }
    public static class DbMigrationHelper
    {
        public static async Task EnsureSeedData(WebApplication application)
        {
            var services = application.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(services);
        }
        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var context = scope.ServiceProvider.GetRequiredService<LojaVirtualContext>();

            if (env.EnvironmentName == "Development")

            {
                await context.Database.MigrateAsync();

                await EnsureSeedTables(context);
            }
        }
        private static async Task EnsureSeedTables(LojaVirtualContext context)
        {
            if (context.CategoriaSet.Any()) return;

            var idUser = Guid.NewGuid();

            var usuarioVendedor = new IdentityUser
            {
                Id = idUser.ToString(),
                Email = "vendedor@teste.com",
                EmailConfirmed = true,
                NormalizedEmail = "VENDEDOR@TESTE.COM",
                UserName = "vendedor@teste.com",
                AccessFailedCount = 0,
                PasswordHash = "AQAAAAIAAYagAAAAEF/nmfwFGPa8pnY9AvZL8HKI7r7l+aM4nryRB+Y3Ktgo6d5/0d25U2mhixnO4h/K5w==",
                NormalizedUserName = "VENDEDOR@TESTE.COM"
            };

            var vendedor = new Vendedor(idUser, "Vendedor", usuarioVendedor.Email);
            var categoria = new Categoria("Informática", "Descrição da categoria Informática");
            var produto = new Produto("Mouse", "Descrição do produto Mouse", "mouse.jpg", 100, 20, true, categoria.Id);
            produto.VinculaVendedor(vendedor.Id);
            categoria.AddProduto(produto);

            await context.Users.AddAsync(usuarioVendedor);
            await context.VendedorSet.AddAsync(vendedor);
            await context.CategoriaSet.AddAsync(categoria);

            var idClienteUser = Guid.NewGuid();
            var userCliente = new IdentityUser
            {
                Id = idClienteUser.ToString(),
                Email = "cliente@teste.com",
                EmailConfirmed = true,
                NormalizedEmail = "CLIENTE@TESTE.COM",
                UserName = "cliente@teste.com",
                AccessFailedCount = 0,
                PasswordHash = "AQAAAAIAAYagAAAAEF/nmfwFGPa8pnY9AvZL8HKI7r7l+aM4nryRB+Y3Ktgo6d5/0d25U2mhixnO4h/K5w==",
                NormalizedUserName = "CLIENTE@TESTE.COM"
            };

            var cliente = new Cliente(idClienteUser, "Cliente", "cliente@teste.com");
            cliente.AddFavorito(produto.Id);
            await context.Users.AddAsync(userCliente);
            await context.ClienteSet.AddAsync(cliente);
            await context.SaveChangesAsync();
        }
    }
}
