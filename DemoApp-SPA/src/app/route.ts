import {Routes} from '@angular/router';
import { RegisterComponent } from './register/register.component';
// import { AuthGuard } from './_guards/auth.guard';

/* Ordering is important here */
export const appRoutes: Routes = [
    { path: 'register', component: RegisterComponent}
];