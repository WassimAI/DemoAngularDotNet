import {Routes} from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { TestUsersComponent } from './test-users/test-users.component';
// import { AuthGuard } from './_guards/auth.guard';

/* Ordering is important here */
export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '', /*what is this empty string? It simply like nothing, so the route will
        be /members, if we put xyz in here, then the route will be //localhost:etc/xyz/members */
        // runGuardsAndResolvers: 'always',
        // canActivate: [AuthGuard],
        children: [
            { path: 'register', component: RegisterComponent},
            { path: 'test', component: TestUsersComponent}
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'}
];