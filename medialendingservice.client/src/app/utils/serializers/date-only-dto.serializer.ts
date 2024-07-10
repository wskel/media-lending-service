import { DateOnlyDto } from "../../models/books/date-only.dto";

export function serializeDateOnlyDto(date: DateOnlyDto | undefined): string | undefined {
  if (!date) {
    return undefined;
  }

  let formattedYear = `${String(date.year).padStart(4, '0')}`
  let formattedMonth = `${String(date.month).padStart(2, '0')}`
  let formattedDay = `${String(date.day).padStart(2, '0')}`

  return `${formattedYear}-${formattedMonth}-${formattedDay}`;
}

export function deserializeDateOnlyDto(dateString: string | undefined): DateOnlyDto | undefined {
  if (!dateString) {
    return undefined;
  }

  const [year, month, day] = dateString.split('-').map(Number);
  if (isNaN(year) || isNaN(month) || isNaN(day)) {
    return undefined;
  }

  return {year, month, day};
}
