import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgFor, NgIf } from '@angular/common';

export interface Assunto {
  id: string;
  codAs: number;
  descricao: string;
}

@Component({
  selector: 'app-subject',
  standalone: true,
  templateUrl: './subject.component.html',
  styleUrl: './subject.component.css',
  imports: [
    NgFor,
    NgIf
  ]
})

export class SubjectComponent implements OnInit {
  public assuntos: Assunto[] = []

  constructor(private readonly http: HttpClient) { }

  ngOnInit() {
    this.getAssunto();
  }

  getAssunto() {
    this.http.get<Assunto[]>('/assunto').subscribe(
      (result) => {
        this.assuntos = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  onDelete(id: string) {
    this.http.delete<any>('/assunto/' + id).subscribe({
      next: data => {
        this.getAssunto();
      },
      error: error => {
        console.error('There was an error!', error);
      }
    });
  }

  title = 'Assunto';
}
