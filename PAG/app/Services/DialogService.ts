import { Injectable } from '@angular/core';


declare var bootbox: any;

interface ButtonData {
    label: string;
    className: string;
    callback: () => void;
}

@Injectable()
export class DialogService {

    private static BUTTON_CLASS_NAME = "btn-inverse btn-inverse-primary";
    private static CONFIRM_BUTTON_CLASS_NAME = "btn-success";
    private static CANCEL_BUTTON_CLASS_NAME = "btn-danger";


    private _title: string;
    private _message: string;
    private _okay: ButtonData;
    private _cancel: ButtonData;

    constructor() { }

    public title(value: string): DialogService {
        this._title = value;
        return this;
    }

    public message(value: string): DialogService {
        this._message = value;
        return this;
    }

    public okay(label: string, callback?: () => void): DialogService {
        this._okay = {
            label: label,
            className: DialogService.CONFIRM_BUTTON_CLASS_NAME,
            callback: callback || function () { }
        };

        return this;
    }

    public cancel(label: string, callback?: () => void): DialogService {
        this._cancel = {
            label: label,
            className: DialogService.CANCEL_BUTTON_CLASS_NAME,
            callback: callback || function () { }
        };

        return this;
    }

    public alert(): void {
        bootbox.dialog({
            title: this._title,
            message: this._message,
            buttons: {
                okay: this._okay
            }
        });
    }

    public confirm(): void {
        bootbox.dialog({
            title: this._title,
            message: this._message,
            buttons: {
                cancel: this._cancel,
                okay: this._okay
            }
        });
    }
}