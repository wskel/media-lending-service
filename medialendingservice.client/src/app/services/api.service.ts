import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { LoggingService } from './logging.service';
import { LoginRequestDto } from "../models/auth/login-request.dto";
import { AccessTokenResponseDto } from "../models/auth/access-token-response.dto";
import { RefreshRequestDto } from "../models/auth/refresh-request.dto";
import { RegisterRequestDto } from "../models/register-request.dto";
import { BookDto } from "../models/books/book.dto";
import { LiteraryCategoryDto } from "../models/books/literary-category.dto";
import { deserializeDateOnlyDto, serializeDateOnlyDto } from "../utils/serializers/date-only-dto.serializer";
import { isString, safeCast } from "../utils/safe-cast";
import { PagedResult } from "../models/paged-result";
import { OrderingSeedService, SEED_KEYS } from "./ordering-seed.service";

export const REFRESH_PATH = "/api/v0/refresh";

// noinspection JSUnusedGlobalSymbols
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  public constructor(
    private logger: LoggingService,
    private http: HttpClient,
    private orderingSeedService: OrderingSeedService) {
  }

  private handleError(error: HttpErrorResponse) {
    this.logger.error('Request error', error);
    return throwError(() => error);
  }

  // Books API
  public getBooks(
    seed: string       = this.orderingSeedService.getOrderingSeed(SEED_KEYS.BOOKS),
    searchTerm: string = '',
    page: number       = 1,
    pageSize: number   = 10
  ): Observable<PagedResult<BookDto> | null> {
    const params = new HttpParams()
      .set('seed', seed)
      .set('searchString', searchTerm)
      .set('pageNumber', page.toString())
      .set('pageSize', pageSize.toString());

    return this.http.get<PagedResult<BookDto>>("/api/v0/Books", {params}).pipe(
      map(result => ({
        ...result,
        items: result.items.map(book => ({
          ...book,
          publicationDate: deserializeDateOnlyDto(safeCast<string>(book.publicationDate, isString))
        }))
      })),
      catchError(this.handleError.bind(this))
    );
  }

  public addBooks(books: BookDto[]): Observable<BookDto[] | null> {
    const serializedBooks = books.map(book => ({
      ...book,
      publicationDate: serializeDateOnlyDto(book.publicationDate)
    }));
    return this.http.post<BookDto[]>("/api/v0/Books", serializedBooks).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  public getBookById(id: number): Observable<BookDto | null> {
    return this.http.get<BookDto>(`/api/v0/Books/${id}`).pipe(
      map(book => ({
        ...book,
        publicationDate: deserializeDateOnlyDto(safeCast<string>(book.publicationDate, isString))
      })),
      catchError(this.handleError.bind(this))
    );
  }

  public updateBook(id: number, book: BookDto): Observable<BookDto | null> {
    const serializedBook = {
      ...book,
      publicationDate: serializeDateOnlyDto(book.publicationDate)
    };
    return this.http.put<BookDto>(`/api/v0/Books/${id}`, serializedBook).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  public deleteBook(id: number): Observable<void> {
    return this.http.delete<void>(`/api/v0/Books/${id}`).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  // LiteraryCategories API
  public getCategories(): Observable<LiteraryCategoryDto[] | null> {
    return this.http.get<LiteraryCategoryDto[]>("/api/v0/LiteraryCategory").pipe(
      catchError(this.handleError.bind(this))
    );
  }

  public addCategory(category: LiteraryCategoryDto): Observable<LiteraryCategoryDto | null> {
    return this.http.post<LiteraryCategoryDto>("/api/v0/LiteraryCategory", category).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  public getCategoryById(id: number): Observable<LiteraryCategoryDto | null> {
    return this.http.get<LiteraryCategoryDto>(`/api/v0/LiteraryCategory/${id}`).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  public updateCategory(id: number, category: LiteraryCategoryDto): Observable<LiteraryCategoryDto | null> {
    return this.http.put<LiteraryCategoryDto>(`/api/v0/LiteraryCategory/${id}`, category).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  public deleteCategory(id: number): Observable<void> {
    return this.http.delete<void>(`/api/v0/LiteraryCategory/${id}`).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  // Authentication API
  public login(request: LoginRequestDto): Observable<AccessTokenResponseDto | null> {
    return this.http.post<AccessTokenResponseDto>("/api/v0/login", request).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  public register(request: RegisterRequestDto): Observable<void> {
    return this.http.post<void>("/api/v0/register", request).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  public refresh(request: RefreshRequestDto): Observable<AccessTokenResponseDto | null> {
    return this.http.post<AccessTokenResponseDto>(REFRESH_PATH, request).pipe(
      catchError(this.handleError.bind(this))
    );
  }
}
