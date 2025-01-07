import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BookComponent } from '../book/book.component';
import { BookCreateComponent } from '../book/book-create/book-create.component';
import { BookEditComponent } from '../book/book-edit/book-edit.component';

import { AuthorComponent } from '../author/author.component';
import { AuthorCreateComponent } from '../author/author-create/author-create.component';
import { AuthorEditComponent } from '../author/author-edit/author-edit.component';

import { SubjectComponent } from '../subject/subject.component';
import { SubjectCreateComponent } from '../subject/subject-create/subject-create.component';
import { SubjectEditComponent } from '../subject/subject-edit/subject-edit.component';

const routes: Routes = [
  { path: 'livro', component: BookComponent },
  { path: 'book-create', component: BookCreateComponent },
  { path: 'book-edit/:id', component: BookEditComponent },

  { path: 'autor', component: AuthorComponent },
  { path: 'author-create', component: AuthorCreateComponent },
  { path: 'author-edit/:id', component: AuthorEditComponent },

  { path: 'assunto', component: SubjectComponent },
  { path: 'subject-create', component: SubjectCreateComponent },
  { path: 'subject-edit/:id', component: SubjectEditComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
