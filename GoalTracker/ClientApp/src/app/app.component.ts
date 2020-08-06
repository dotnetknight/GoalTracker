import { Component, OnInit, HostListener } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  showToggle: string;
  mode: string;
  openSidenav: boolean;
  private screenWidth$ = new BehaviorSubject<number>
    (window.innerWidth);

  constructor() { }

  ngOnInit() {
    this.getScreenWidth().subscribe(width => {
      if (width < 500) {
        this.showToggle = 'hide';
        this.mode = 'over';
        this.openSidenav = false;
        console.log("< 500");
      }

      else if (width > 500) {
        console.log("> 500");

        this.showToggle = 'hide';
        this.mode = 'side';
        this.openSidenav = true;
      }
    });
  }

  @HostListener('window:resize', ['$event'])
  onResize(event) {
    this.screenWidth$.next(event.target.innerWidth);
  }
  getScreenWidth(): Observable<number> {
    return this.screenWidth$.asObservable();
  }
}