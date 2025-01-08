import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-subject-create',
  standalone: true,
  templateUrl: './subject-create.component.html',
  styleUrl: './subject-create.component.css',
  imports: [
    ReactiveFormsModule
  ]
})
export class SubjectCreateComponent implements OnInit {
  public subjectCreate: FormGroup = new FormGroup({});
  constructor(private readonly http: HttpClient, private readonly router: Router) { }

  ngOnInit() {
    this.subjectCreate = new FormGroup({
      descricao: new FormControl('', Validators.required),
    });
  }

  onSubmit() {
    this.postAssunto(this.subjectCreate.value);
  }

  postAssunto(assunto: FormGroup) {
    this.http.post<any>('/assunto', assunto).subscribe({
      next: data => {
        this.router.navigateByUrl('/assunto');
      },
      error: error => {
        console.error('There was an error!', error);
      }
    });
  }
}
