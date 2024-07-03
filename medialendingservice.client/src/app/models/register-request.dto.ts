import { UserRoleDto } from "./user-role.dto";

export interface RegisterRequestDto {
  email: string;
  password: string;
  preferredName: string | null;
  role: UserRoleDto;
}
