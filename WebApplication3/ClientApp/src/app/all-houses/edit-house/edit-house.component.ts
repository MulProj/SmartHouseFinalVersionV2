import { Component, OnInit, Input } from '@angular/core';
import { HttpService } from 'src/app/Service/http.service';
import { House } from 'src/app/app.component';

@Component({
  selector: 'app-edit-house',
  templateUrl: './edit-house.component.html',
  styleUrls: ['./edit-house.component.css']
})
export class EditHouseComponent implements OnInit {

  newHouse: House = new House();



  @Input()
  houseId;

  constructor(private httpService: HttpService) { }

  ngOnInit() {
    this.httpService.getHousebyId(this.houseId).subscribe(house=>
      {
      this.newHouse.houseId = this.houseId,
      this.newHouse.postCode=house.postCode,
      this.newHouse.town=house.town,
      this.newHouse.street = house.street,
      this.newHouse.houseNumber=house.houseNumber,
      this.newHouse.description=house.description,
      this.newHouse.image=house.image

      })
  }
  getBase64(event) {
    let file = event.target.files[0];
    let reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onloadend = ()=> {
      this.newHouse.image=reader.result.toString();
    };
    reader.onerror = function (error) {
    console.log('Error: ', error);
    };
  }
  save(){
    console.log(this.newHouse)
    var nw: House=({
      houseId: this.newHouse.houseId,
      postCode: this.newHouse.postCode,
      town: this.newHouse.town,
      street: this.newHouse.street,
      houseNumber: this.newHouse.houseNumber,
      description: this.newHouse.description,
      image: this.newHouse.image,
    })
    this.httpService.updateHouse(nw).subscribe(      
      success=>{console.log("success")},
      error=>{console.log("error")}) ;

  }

}
