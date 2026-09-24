import { Routes } from '@angular/router';
import { BookListComponent } from './components/book-list/book-list';
import { AddBookComponent } from './components/add-book/add-book';
import { EditBookComponent } from './components/edit-book/edit-book';
import { SearchBookComponent } from './components/search-book/search-book';

export const routes: Routes = [
  {
    path: '',
    component: BookListComponent
  },
  {
    path: 'add-book',
    component: AddBookComponent
  },
  {
    path: 'edit-book/:id',
    component: EditBookComponent
  },
  {
    path: 'search-book',
    component: SearchBookComponent
  }
];