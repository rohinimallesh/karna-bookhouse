  import { Component } from '@angular/core';
import { BookService } from '../../services/book.service';
import { FormsModule } from '@angular/forms';


  @Component({
    imports: [FormsModule],
    selector: 'app-add-book',
    standalone: true,
    styleUrl: './add-book.css',
    templateUrl: './add-book.html',
  })
  export class AddBook {
    title = '';
  author = '';
  category = '';
   
  successMessage = '';
  errorMessage = '';
   
  constructor(private bookService: BookService) {}
   
  saveBook() {
      console.log("Title:", this.title);
      console.log("Author:", this.author);
      console.log("Category:", this.category);
   
  const book = {
  title: this.title,
  author: this.author,
  category: this.category
  };
  
  console.log(book); 

  this.bookService.addBook(book)
  .subscribe({
  next: () => {
   
  this.successMessage =
  'Book added successfully';
  },
  error: (error) => {
console.error(error);
}
   
    });
  } 
}