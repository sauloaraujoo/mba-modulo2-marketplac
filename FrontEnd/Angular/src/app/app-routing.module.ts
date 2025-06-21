import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './conta/login/login.component';
import { CadastroClienteComponent } from './conta/cadastro-cliente/cadastro-cliente.component';
import { EditarClienteComponent } from './conta/editar-cliente/editar-cliente.component';
import { ListaComponent } from './produtos/lista/lista.component';
import { ProdutoComponent } from './produtos/produto/produto.component';
import { FavoritosComponent } from './produtos/favoritos/favoritos.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'cadastro-cliente', component: CadastroClienteComponent },
  { path: 'edicao-cliente', component: EditarClienteComponent },
  { path: 'produtos', component: ListaComponent },
  { path: 'produto', component: ProdutoComponent },
  { path: 'favoritos', component: FavoritosComponent },

  // Redirecionamento opcional da raiz para login
  { path: '', redirectTo: 'produtos', pathMatch: 'full' },

  // Rota curinga (404)
  { path: '**', redirectTo: 'produtos' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
