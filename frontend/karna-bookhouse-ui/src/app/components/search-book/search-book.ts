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

  searchBooks() {

    this.bookService
      .searchBook(this.searchText)
      .subscribe(data => {

        this.books = data;

      });

  }

}