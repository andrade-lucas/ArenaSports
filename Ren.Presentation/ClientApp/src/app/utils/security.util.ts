import { UserAuthModel } from '../models/authUser.model';

export class Security {
    public static set(user: UserAuthModel, token: string, expiration: string) {
        const data = JSON.stringify(user);

        localStorage.setItem('ren.user', btoa(data));
        localStorage.setItem('ren.token', token);
        localStorage.setItem('ren.expiration', expiration);
    }

    public static setUser(user: UserAuthModel) {
        const data = JSON.stringify(user);
        localStorage.setItem('ren.user', btoa(data));
    }

    public static setToken(token: string) {
        localStorage.setItem('ren.token', token);
    }

    public static getUser() {
        const data = localStorage.getItem('ren.user');
        if (data)
            return JSON.parse(atob(data));
        return null;
    }

    public static getToken() {
        const data = localStorage.getItem('ren.token');
        if (data)
            return data;
        return null;
    }

    public static hasToken(): boolean {
        if (this.getToken())
            return true;
        return false;
    }

    public static getExpiration(): string {
        const expiration = localStorage.getItem('ren.expiration');
        if (expiration)
            return expiration;
        return null;
    }

    public static clear() {
        localStorage.removeItem('ren.user');
        localStorage.removeItem('ren.token');
        localStorage.removeItem('ren.expiration');
    }
}