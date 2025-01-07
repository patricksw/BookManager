import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-book-create',
  standalone: true,
  templateUrl: './book-create.component.html',
  styleUrl: './book-create.component.css',
  imports: [
    ReactiveFormsModule
  ]
})

export class BookCreateComponent implements OnInit {
  public bookCreate: FormGroup = new FormGroup({});
  constructor(private readonly http: HttpClient, private readonly router: Router) { }

  ngOnInit() {
    this.bookCreate = new FormGroup({
      titulo: new FormControl('', Validators.required),
      editora: new FormControl('', [Validators.required]),
      edicao: new FormControl('', Validators.required),
      anoPublicacao: new FormControl('', Validators.required),
    });
  }

  onSubmit() {
    console.log(this.bookCreate.value);
    this.postLivro(this.bookCreate.value);
  }

  postLivro(livro: FormGroup) {
    this.http.post<any>('/livro', livro).subscribe({
      next: data => {
        this.router.navigateByUrl('/livro');
      },
      error: error => {
        console.error('There was an error!', error);
      }
    });
  }
}
