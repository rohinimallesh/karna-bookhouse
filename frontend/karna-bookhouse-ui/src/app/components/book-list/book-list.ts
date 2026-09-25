import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookService } from '../../services/book.service';
import { Book } from '../../models/book';

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './book-list.html',
  styleUrl: './book-list.css'
})
export class BookList implements OnInit {

  books: Book[] = [];

  constructor(private bookService: BookService) {}

  ngOnInit(): void {
    this.loadBooks();
  }

  loadBooks(): void {

    this.bookService.getAllBooks()
      .subscribe({
        next: (data) => {

          console.log('Books Received:', data);

          this.books = data;

          console.log('Books Length:', this.books.length);

        },
        error: (error) => {
          console.error(error);
        }
      });

  }
}