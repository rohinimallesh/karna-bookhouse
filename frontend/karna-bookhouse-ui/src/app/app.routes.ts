import { Routes } from '@angular/router';
import { BookList } from './components/book-list/book-list';
import { AddBook } from './components/add-book/add-book';
import { EditBook } from './components/edit-book/edit-book';
import { SearchBook } from './components/search-book/search-book';


export const routes: Routes = [
  {
    path: '',
    component: BookList
  },
  {
    path: 'add-book',
    component: AddBook
  },
  {
    path: 'edit-book/:id',
    component: EditBook
  },
  {
    path: 'search-book',
    component: SearchBook
  }
];