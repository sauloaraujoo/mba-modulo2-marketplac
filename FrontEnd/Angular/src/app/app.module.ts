import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './navegacao/menu/menu.component';
import { FooterComponent } from './navegacao/footer/footer.component';
import { ListaComponent } from './produtos/lista/lista.component';
import { ProdutoComponent } from './produtos/produto/produto.component';
import { LoginComponent } from './conta/login/login.component';
import { CadastroClienteComponent } from './conta/cadastro-cliente/cadastro-cliente.component';
import { EditarClienteComponent } from './conta/editar-cliente/editar-cliente.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    FooterComponent,
    ListaComponent,
    ProdutoComponent,
    LoginComponent,
    CadastroClienteComponent,
    EditarClienteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
