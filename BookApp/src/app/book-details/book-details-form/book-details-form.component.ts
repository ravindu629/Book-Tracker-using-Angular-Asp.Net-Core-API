import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BookDetailsService } from 'src/app/shared/book-details.service';
import { BookDetails } from 'src/app/shared/book-details.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-book-details-form',
  templateUrl: './book-details-form.component.html',
  styles: [],
})
export class BookDetailsFormComponent {
  constructor(
    public service: BookDetailsService,
    private toastr: ToastrService
  ) {}

  onSubmit(form: NgForm) {
    this.service.formSubmitted = true;
    if (form.valid) {
      if (this.service.formData.bookId == 0) this.insertRecord(form);
      else this.updateRecord(form);
    }
  }

  insertRecord(form: NgForm) {
    this.service.postBookDetails().subscribe({
      next: (res) => {
        this.service.list = res as BookDetails[];
        this.service.resetForm(form);
        this.toastr.success('Inserted book detais successfully', 'Book App');
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
  updateRecord(form: NgForm) {
    this.service.putBookDetails().subscribe({
      next: (res) => {
        this.service.list = res as BookDetails[];
        this.service.resetForm(form);
        this.toastr.info('Updated book details successfully', 'Book App');
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
}
