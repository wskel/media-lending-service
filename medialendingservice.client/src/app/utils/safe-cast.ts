export function safeCast<T>(value: any, typeCheck: (val: any) => val is T): T | undefined {
  return typeCheck(value) ? value : undefined;
}

export function isString(value: any): value is string {
  return typeof value === 'string';
}
