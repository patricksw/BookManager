import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

export interface Livro {
  id: string;
  codI: number;
  titulo: number;
  editora: string;
  edicao: string;
  anoPublicacao: string;
}

@Component({
  selector: 'app-book-edit',
  standalone: true,
  templateUrl: './book-edit.component.html',
  styleUrl: './book-edit.component.css',
  imports: [
    ReactiveFormsModule
  ]
})

export class BookEditComponent implements OnInit {
  public bookEdit: FormGroup = new FormGroup({});
  public id: string = '';
  constructor(private readonly http: HttpClient,
    private readonly router: Router,
    private readonly route: ActivatedRoute) { }

  ngOnInit() {
    this.bookEdit = new FormGroup({
      titulo: new FormControl('', Validators.required),
      editora: new FormControl('', [Validators.required]),
      edicao: new FormControl('', Validators.required),
      anoPublicacao: new FormControl('', Validators.required),
    });

    this.route.params.subscribe(params => {
      this.id = params["id"];
    });

    this.getLivro(this.id);
  }

  onSubmit() {
    console.log(this.bookEdit.value);
    this.editLivro(this.id, this.bookEdit.value);
  }

  getLivro(id: string) {
    this.http.get<Livro>('/livro/'+id).subscribe(
      (result) => {
        this.bookEdit.patchValue(result);
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  editLivro(id: string, livro: FormGroup) {
    this.http.put<any>('/livro/' + id, livro).subscribe({
      next: data => {
        console.log(data);
        this.router.navigateByUrl('/livro');
      },
      error: error => {
        console.error('There was an error!', error);
      }
    });
  }
}
