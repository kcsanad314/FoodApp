export interface AuthResponseDto {
    isAuthSuccessful: boolean;
    errorMessage: string;
    token: string;
    claims: { [index: string]: string; }
    userId: string;
}