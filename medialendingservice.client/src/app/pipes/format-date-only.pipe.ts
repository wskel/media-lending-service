import { Pipe, PipeTransform } from '@angular/core';
import { DateOnlyDto } from "../models/books/date-only.dto";
import { serializeDateOnlyDto } from "../utils/serializers/date-only-dto.serializer";

@Pipe({
  name: 'formatDateOnly'
})
export class FormatDateOnlyPipe implements PipeTransform {
  public transform = (date: DateOnlyDto | undefined): string =>
    serializeDateOnlyDto(date) || ''
}
