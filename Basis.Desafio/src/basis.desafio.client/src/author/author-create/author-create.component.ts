import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-author-create',
  standalone: true,
  templateUrl: './author-create.component.html',
  styleUrl: './author-create.component.css',
  imports: [
    ReactiveFormsModule
  ]
})
export class AuthorCreateComponent implements OnInit {
  public authorCreate: FormGroup = new FormGroup({});
  constructor(private readonly http: HttpClient, private readonly router: Router) { }

  ngOnInit() {
    this.authorCreate = new FormGroup({
      nome: new FormControl('', Validators.required)
    });
  }

  onSubmit() {
    this.postAuthor(this.authorCreate.value);
  }

  postAuthor(autor: FormGroup) {
    this.http.post<any>('/autor', autor).subscribe({
      next: data => {
        this.router.navigateByUrl('/autor');
      },
      error: error => {
        console.error('There was an error!', error);
      }
    });
  }
}
