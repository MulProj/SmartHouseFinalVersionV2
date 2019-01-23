import { Component, OnInit, Input } from '@angular/core';
import { HttpService } from 'src/app/Service/http.service';
import { TemperatureSensor, HumiditySensor, SmokeSensor } from 'src/app/app.component';

@Component({
  selector: 'app-edit-sensor',
  templateUrl: './edit-sensor.component.html',
  styleUrls: ['./edit-sensor.component.css']
})
export class EditSensorComponent implements OnInit{
  @Input()
  sensorId: number;
  @Input()
  sensorType: string;
  @Input()
  name: string;
  @Input()
  minValue: number;
  @Input()
  maxValue: number;
  @Input()
  houseId: number;
  @Input()
  coordinateX: number;
  @Input()
  coordinateY: number;



  constructor(private httpService: HttpService) { }

  ngOnInit(){


  }

  saveSensor(){
    if(this.sensorType=="Temperature")
    {
      var ts: TemperatureSensor=({
        sensorId: this.sensorId,
        coordinateX: this.coordinateX,
        coordinateY: this.coordinateY,
        type: this.sensorType,
        maxValue: this.maxValue,
        minValue: this.minValue,
        name: this.name,
        houseId: this.houseId,
      })
      this.httpService.updateTemperatureSensor(ts).subscribe(
      success=>{},
      error=>{}) 
    }
    else if(this.sensorType=="Humidity")
    {
      var hs: HumiditySensor=({
        sensorId: this.sensorId,
        coordinateX: this.coordinateX,
        coordinateY: this.coordinateY,
        type: this.sensorType,
        maxValue: this.maxValue,
        minValue: this.minValue,
        name: this.name,
        houseId: this.houseId,
      })
      this.httpService.updateHumiditySensor(hs).subscribe(
      success=>{},
      error=>{}) 

    }
    else
    {
      var ss: SmokeSensor=({
        sensorId: this.sensorId,
        coordinateX: this.coordinateX,
        coordinateY: this.coordinateY,
        type: this.sensorType,
        maxValue: this.maxValue,
        minValue: this.minValue,
        name: this.name,
        houseId: this.houseId,
      })
      this.httpService.updateSmokeSensor(ss).subscribe(
      success=>{},
      error=>{}) 

    }

  }

}
