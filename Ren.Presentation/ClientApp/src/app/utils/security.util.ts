import { UserAuth } from '../models/authUser.model';

export class Security {
    public static set(user: UserAuth, token: string) {
        const data = JSON.stringify(user);

        localStorage.setItem('ren.user', btoa(data));
        localStorage.setItem('ren.token', token);
    }

    public static setUser(user: UserAuth) {
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

    public static clear() {
        localStorage.removeItem('ren.user');
        localStorage.removeItem('ren.token');
    }
}