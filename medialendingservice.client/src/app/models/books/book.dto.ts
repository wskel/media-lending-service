import { LiteraryCategoryDto } from "./literary-category.dto";
import { DateOnlyDto } from "./date-only.dto";

export interface BookDto {
  id: number;
  title?: string;
  author?: string;
  description?: string;
  coverImage?: string;
  publisher?: string;
  publicationDate?: DateOnlyDto;
  category?: LiteraryCategoryDto;
  isbn?: string;
  pageCount: number;
  isCheckedOut: boolean;
}
