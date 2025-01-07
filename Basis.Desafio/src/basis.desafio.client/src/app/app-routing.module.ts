import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookComponent } from '../book/book.component';
import { BookCreateComponent } from '../book/book-create/book-create.component';
import { BookEditComponent } from '../book/book-edit/book-edit.component';

const routes: Routes = [
  { path: 'livro', component: BookComponent },
  { path: 'book-create', component: BookCreateComponent },
  { path: 'book-edit/:id', component: BookEditComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
