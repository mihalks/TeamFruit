
export interface Group {
    name: string;
    lessons: Lesson[];
}

export interface Lesson {
    subject: string;
    type: Type;
    time: Time;
    date: DateClass;
    audiences: Audience[];
    teachers: Audience[];
}

export interface Audience {
    name: string;
}

export interface DateClass {
    start: string;
    end: string;
    weekday: number;
    week: number;
}
export interface Time {
    start: string;
    end: string;
}

export enum Type {
    Empty = "—",
    Лаб = "лаб.",
    Лк = "лк.",
    ПрЗ = "пр.з.",
}