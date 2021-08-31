export interface Movie {
    id: number;
    imageUrl: string | null;
    title: string | null;
}

export interface UserLogin {
    password: string | null;
    userName: string | null;
}