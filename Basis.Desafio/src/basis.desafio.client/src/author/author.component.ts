import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgFor, NgIf } from '@angular/common';

export interface Autor {
  id: string;
  codAu: number;
  nome: string;
}

@Component({
  selector: 'app-author',
  standalone: true,
  templateUrl: './author.component.html',
  styleUrl: './author.component.css',
  imports: [
    NgFor,
    NgIf
  ]
})

export class AuthorComponent implements OnInit {
  public autores: Autor[] = []

  constructor(private readonly http: HttpClient) { }

  ngOnInit() {
    this.getAutores();
  }

  getAutores() {
    this.http.get<Autor[]>('/autor').subscribe(
      (result) => {
        this.autores = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  onDelete(id: string) {
    this.http.delete<any>('/autor/' + id).subscribe({
      next: data => {
        this.getAutores();
      },
      error: error => {
        console.error('There was an error!', error);
      }
    });
  }

  title = 'Autor';
}
