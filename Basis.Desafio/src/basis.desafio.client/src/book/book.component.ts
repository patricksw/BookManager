import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgFor, NgIf } from '@angular/common';
export interface Livro {
  id: string;
  codI: number;
  titulo: number;
  editora: string;
  edicao: string;
  anoPublicacao: string;
}

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  standalone: true,
  styleUrl: './book.component.css',
  imports: [
    NgFor,
    NgIf
  ]
})

export class BookComponent implements OnInit {
  public livros: Livro[] = []

  constructor(private readonly http: HttpClient) { }

  ngOnInit() {
    this.getLivros();
  }

  getLivros() {
    this.http.get<Livro[]>('/livro').subscribe(
      (result) => {
        this.livros = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'Livro';
}
