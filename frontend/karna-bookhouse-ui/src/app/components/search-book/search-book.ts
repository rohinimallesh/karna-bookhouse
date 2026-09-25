import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BookService } from '../../services/book.service';

@Component({
  selector: 'app-search-book',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './search-book.html',
  styleUrl: './search-book.css'
})
export class SearchBook {

  searchText = '';

  books: any[] = [];

  constructor(private bookService: BookService) {}

  searchBooks(): void {

    this.bookService.searchBook(this.searchText)
      .subscribe({
        next: (data) => {

          console.log(data);

          this.books = data;

        },
        error: (error) => {

          console.error(error);

        }
      });

  }
}