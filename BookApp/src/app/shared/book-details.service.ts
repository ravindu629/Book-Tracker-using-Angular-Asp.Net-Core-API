import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { BookDetails } from './book-details.model';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root',
})
export class BookDetailsService {
  url: string = environment.apiBaseUrl + '/BookDetail';
  list: BookDetails[] = [];
  formData: BookDetails = new BookDetails();
  formSubmitted: boolean = false;
  constructor(private http: HttpClient) {}

  refreshList() {
    this.http.get(this.url).subscribe({
      next: (res) => {
        this.list = res as BookDetails[];
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  postBookDetails() {
    return this.http.post(this.url, this.formData);
  }

  putBookDetails() {
    return this.http.put(this.url + '/' + this.formData.bookId, this.formData);
  }

  deleteBookDetails(id: number) {
    return this.http.delete(this.url + '/' + id);
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.formData = new BookDetails();
    this.formSubmitted = false;
  }
}
