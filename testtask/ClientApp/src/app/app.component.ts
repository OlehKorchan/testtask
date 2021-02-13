import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { User } from "./user";

@Component({
	selector: 'app',
	templateUrl: './app.component.html',
	providers: [DataService]
})
export class AppComponent implements OnInit {
	
	user: User = new User();  
	users: User[];                
	tableMode: boolean = true;
	total: number;
	active: number;
	constructor(private dataService: DataService) { }
 
	ngOnInit() {
		this.loadUsers();   
	}
	loadUsers() {
		this.dataService.getUsers()
			.subscribe((data: User[]) => this.users = data);
		this.total = 0;
		this.active = 0;
		this.users.forEach((item) => {
			this.total++;
			if (item.active) {
				this.active++;
			}
		});
	}
	save(user: User) {
		//user.active = active;
		this.dataService.updateUser(user)
				.subscribe(data => this.loadUsers());
	}
	show() {
		
	}
}