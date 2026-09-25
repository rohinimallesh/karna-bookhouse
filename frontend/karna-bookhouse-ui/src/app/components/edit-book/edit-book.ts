import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BookService } from '../../services/book.service';

@Component({
  selector: 'app-edit-book',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './edit-book.html',
  styleUrl: './edit-book.css'
})
export class EditBook implements OnInit {

  id = 0;

  title = '';

  author = '';

  category = '';

  constructor(
    private route: ActivatedRoute,
    private bookService: BookService
  ) {}

  ngOnInit(): void {

    this.id =
      Number(
        this.route.snapshot.paramMap.get('id')
      );

    this.loadBook();

  }

  loadBook() {

    this.bookService
      .getBookById(this.id)
      .subscribe(book => {

        this.title = book.title;
        this.author = book.author;
        this.category = book.category;

      });

  }

  updateBook() {

    const book = {

      title: this.title,

      author: this.author,

      category: this.category

    };

    this.bookService
      .updateBook(this.id, book)
      .subscribe(() => {

        alert('Book Updated Successfully');

      });

  }

}
