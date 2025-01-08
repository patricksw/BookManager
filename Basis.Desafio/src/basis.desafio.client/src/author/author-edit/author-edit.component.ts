import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

export interface Autor {
  id: string;
  codAu: number;
  nome: string;
  anoPublicacao: string;
}

@Component({
  selector: 'app-author-edit',
  standalone: true,
  templateUrl: './author-edit.component.html',
  styleUrl: './author-edit.component.css',
  imports: [
    ReactiveFormsModule
  ]
})

export class AuthorEditComponent implements OnInit {
  public authorEdit: FormGroup = new FormGroup({});
  public id: string = '';

  constructor(private readonly http: HttpClient,
    private readonly router: Router,
    private readonly route: ActivatedRoute) { }

  ngOnInit() {
    this.authorEdit = new FormGroup({
      nome: new FormControl('', Validators.required)
    });

    this.route.params.subscribe(params => {
      this.id = params["id"];
    });

    this.getAutor(this.id);
  }

  onSubmit() {
    this.editAutor(this.id, this.authorEdit.value);
  }

  getAutor(id: string) {
    this.http.get<Autor>('/autor/' + id).subscribe(
      (result) => {
        this.authorEdit.patchValue(result);
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  editAutor(id: string, autor: FormGroup) {
    this.http.put<any>('/autor/' + id, autor).subscribe({
      next: data => {
        console.log(data);
        this.router.navigateByUrl('/autor');
      },
      error: error => {
        console.error('There was an error!', error);
      }
    });
  }
}
