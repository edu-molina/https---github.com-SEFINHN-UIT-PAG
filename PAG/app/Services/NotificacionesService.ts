import { Injectable, Component, OnInit } from '@angular/core';

import { ToastyService, ToastyConfig, ToastOptions, ToastData } from 'ng2-toasty';
import { Subject, Observable, Subscription } from 'rxjs/Rx';

@Injectable()
export class NotificacionesService {

    constructor(private toastyService: ToastyService) {
    }
    getTitle(num: number): string {
        return 'Countdown: ' + num;
    }

    getMessage(num: number): string {
        return 'Seconds left: ' + num;
    }

    themes = [{
        name: 'Default Theme',
        code: 'default'
    }, {
        name: 'Material Design',
        code: 'material'
    }, {
        name: 'Bootstrap 3',
        code: 'bootstrap'
    }];

    types = [{
        name: 'Default',
        code: 'default',
    }, {
        name: 'Info',
        code: 'info'
    }, {
        name: 'Success',
        code: 'success'
    }, {
        name: 'Wait',
        code: 'wait'
    }, {
        name: 'Error',
        code: 'error'
    }, {
        name: 'Warning',
        code: 'warning'
    }];

    positions = [{
        name: 'Top Left',
        code: 'top-left',
    }, {
        name: 'Top Center',
        code: 'top-center',
    }, {
        name: 'Top Right',
        code: 'top-right',
    }, {
        name: 'Bottom Left',
        code: 'bottom-left',
    }, {
        name: 'Bottom Center',
        code: 'bottom-center',
    }, {
        name: 'Bottom Right',
        code: 'bottom-right',
    }, {
        name: 'Center Center',
        code: 'center-center',
    }];

    position: string = this.positions[5].code;

    options = {
        title: 'Toast It!',
        msg: 'Mmmm, tasties...',
        showClose: false,
        timeout: 300000,
        theme: this.themes[1].code,
        type: this.types[0].code
    };
    addToast(title?: string, message?: string) {
        let interval = 300000;
        let subscription: Subscription;

        let toastOptions: ToastOptions = {
            title: (title == null ? "" : title),
            msg: (message == null ? "" : message),
            showClose: true,
            theme: 'default',
            onAdd: (toast: ToastData) => {
                //console.log('Toast ' + toast.id + ' has been added!');
                // Run the timer with 1 second iterval
                let observable = Observable.interval(interval);
                // Start listen seconds beat
                subscription = observable.subscribe((count: number) => {
                    // Update title of toast
                    toast.title = this.getTitle(count);
                    // Update message of toast
                    toast.msg = this.getMessage(count);
                    // Extra condition to hide Toast after 10 sec
                    if (count > 60) {
                        // We use toast id to identify and hide it
                        this.toastyService.clear(toast.id);
                    }
                });

            },
            onRemove: function (toast: ToastData) {
                //console.log('Toast ' + toast.id + ' has been removed!');
                // Stop listenning
                subscription.unsubscribe();
            }
        };

        switch (this.options.type) {
            case 'default': this.toastyService.default(toastOptions); break;
            case 'info': this.toastyService.info(toastOptions); break;
            case 'success': this.toastyService.success(toastOptions); break;
            case 'wait': this.toastyService.wait(toastOptions); break;
            case 'error': this.toastyService.error(toastOptions); break;
            case 'warning': this.toastyService.warning(toastOptions); break;
        }
    }
    Default(message?: string) {
        this.options.type = this.types[0].code;
        this.addToast("Notificación", message);
    }
    Info(message?: string) {
        this.options.type = this.types[1].code;
        this.addToast("Información", message);
    }
    Warning(message?: string) {
        this.options.type = this.types[5].code;
        this.addToast("Advertencia", message);
    }
    Error(message?: string) {
        this.options.type = this.types[4].code;
        this.addToast("Error", message);
    }
    Success(message?: string) {
        this.options.type = this.types[2].code;
        this.addToast("Exitoso", message);
    }
    Wait(message?: string) {
        this.options.type = this.types[3].code;
        this.addToast("Espera", message);
    }
}