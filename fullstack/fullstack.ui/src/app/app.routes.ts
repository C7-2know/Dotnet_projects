import { Routes } from '@angular/router';
import { EmployeesListComponent } from './Components/Employees/employees-list/employees-list.component';

export const routes: Routes = [
    {
        path:"",
        component:EmployeesListComponent
    },
    {
        path:"employees",
        component:EmployeesListComponent
    }
];
