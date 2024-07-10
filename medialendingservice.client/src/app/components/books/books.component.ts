import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { BookDto } from "../../models/books/book.dto";
import { BehaviorSubject, of, tap } from 'rxjs';
import { catchError, debounceTime, delay, finalize, map } from 'rxjs/operators';
import { FormControl } from '@angular/forms';
import { PagedResult } from '../../models/paged-result';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss']
})
export class BooksComponent implements OnInit {
  protected books$ = new BehaviorSubject<PagedResult<BookDto>>({items: [], totalCount: 0, pageNumber: 1, pageSize: 10});
  protected isLoading$ = new BehaviorSubject<boolean>(false);
  protected error$ = new BehaviorSubject<Error | null>(null);

  protected searchControl = new FormControl('');
  protected currentPage = 1;
  protected pageSize = 16;

  constructor(private apiService: ApiService) {
  }

  ngOnInit(): void {
    this.searchControl.valueChanges.pipe(
      debounceTime(300),
      tap(() => {
          this.currentPage = 1;
          this.loadBooks();
        }
      ),
    ).subscribe();

    this.loadBooks();
  }

  protected loadBooks(): void {
    this.isLoading$.next(true);
    this.error$.next(null);
    let emptyResult = {items: [], totalCount: 0, pageNumber: this.currentPage, pageSize: this.pageSize};

    this.apiService.getBooks(undefined, this.searchControl.value || '', this.currentPage, this.pageSize).pipe(
      delay(300), // delay for demo purposes
      map(result => result ?? emptyResult),
      tap(result => {
        this.books$.next(result);
      }),
      catchError((error: Error) => {
        this.error$.next(error);
        this.books$.next(emptyResult);
        return of(emptyResult);
      }),
      finalize(() => {
        this.isLoading$.next(false);
      })
    ).subscribe()
  }

  protected onPageChange(page: number): void {
    this.currentPage = page;
    this.loadBooks();
  }
}
