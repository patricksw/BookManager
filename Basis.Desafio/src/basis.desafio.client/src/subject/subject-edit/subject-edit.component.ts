import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

export interface Assunto {
  id: string;
  codAs: number;
  descricao: string;
}

@Component({
  selector: 'app-subject-edit',
  standalone: true,
  templateUrl: './subject-edit.component.html',
  styleUrl: './subject-edit.component.css',
  imports: [
    ReactiveFormsModule
  ]
})

export class SubjectEditComponent implements OnInit{
  public subjectEdit: FormGroup = new FormGroup({});
  public id: string = '';
  constructor(private readonly http: HttpClient,
    private readonly router: Router,
    private readonly route: ActivatedRoute) { }

  ngOnInit() {
    this.subjectEdit = new FormGroup({
      descricao: new FormControl('', Validators.required)
    });

    this.route.params.subscribe(params => {
      this.id = params["id"];
    });

    this.getAssunto(this.id);
  }

  onSubmit() {
    this.editAssunto(this.id, this.subjectEdit.value);
  }

  getAssunto(id: string) {
    this.http.get<Assunto>('/assunto/' + id).subscribe(
      (result) => {
        this.subjectEdit.patchValue(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  editAssunto(id: string, assunto: FormGroup) {
    this.http.put<any>('/assunto/' + id, assunto).subscribe({
      next: data => {
        this.router.navigateByUrl('/assunto');
      },
      error: error => {
        console.error('There was an error!', error);
      }
    });
  }
}
