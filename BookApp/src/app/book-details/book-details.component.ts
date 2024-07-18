import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BookDetails } from '../shared/book-details.model';
import { BookDetailsService } from '../shared/book-details.service';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styles: [],
})
export class BookDetailsComponent implements OnInit {
  constructor(
    public service: BookDetailsService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: BookDetails) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?'))
      this.service.deleteBookDetails(id).subscribe({
        next: (res) => {
          this.service.list = res as BookDetails[];
          this.toastr.error('Deleted successfully', 'Book App');
        },
        error: (err) => {
          console.log(err);
        },
      });
  }
}
