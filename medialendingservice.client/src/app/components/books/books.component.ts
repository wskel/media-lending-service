import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { BookDto } from "../../models/books/book.dto";
import { BehaviorSubject, Observable, of } from 'rxjs';
import { catchError, delay, finalize, map } from 'rxjs/operators';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss']
})
export class BooksComponent implements OnInit {
  protected books$: Observable<BookDto[]> = of([]);
  protected isLoading$ = new BehaviorSubject<boolean>(false);
  protected error$ = new BehaviorSubject<Error | null>(null);

  public constructor(private apiService: ApiService) {
  }

  public ngOnInit(): void {
    this.loadBooks();
  }

  protected loadBooks(): void {
    this.isLoading$.next(true);
    this.error$.next(null);

    this.books$ = this.apiService.getBooks().pipe(
      delay(500), // delay for demo purposes
      map((books): BookDto[] => {
        return books || [];
      }),
      catchError((error: Error) => {
        this.error$.next(error);
        return of([]);
      }),
      finalize(() => {
        this.isLoading$.next(false);
      })
    );
  }
}
