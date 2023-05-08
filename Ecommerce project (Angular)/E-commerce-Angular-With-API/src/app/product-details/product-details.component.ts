import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { ProductService } from '../Services/product.service';
import { IProduct } from '../SharedClassesAndTypes/IProduct';
import { CartService } from '../Services/cart.service';
import { ReviewService } from '../Services/review.service';
import { IReview } from '../SharedClassesAndTypes/IReview';
import { FormBuilder, FormGroup } from '@angular/forms';
import { LoginService } from '../Services/login.service';
import { AddReview } from '../SharedClassesAndTypes/AddReview';
import { CustomerService } from '../Services/customer.service';
import { ICart } from '../SharedClassesAndTypes/ICart';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  productId: any;
  Product!: IProduct;
  productTemp!:IProduct;
  ErrorMessage: string = "";
  Review!: IReview
  ReviewForm!: FormGroup;
  reviewModel = new AddReview(0, '', new Date(), 0);
  ReviewsByProductId:any[]=[];
  result:IReview[]=[];
  dateFormat:any;
  ApplicationUserID:string='';
  AppUserID:string=(JSON.parse(JSON.stringify(this.loginService.currentUser.getValue()))).ID;
  customerID!:number;
  customerIdetifier!:number

  Products: IProduct[] = [];
  SelectQuantity: number=1;

  tempPrice:any[]=[];
  constructor(private activatedRoute: ActivatedRoute, private productsService: ProductService,
    private cartService: CartService, private reviewServise: ReviewService
    , private fb: FormBuilder, private loginService: LoginService,private customerService:CustomerService)
    {

     }
  ngOnInit(): void {

      this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
        this.productId = params.get("id");
      })

      this.customerService.GetCustomerID(this.AppUserID).subscribe({
        next : data=>{
          this.customerID=data.data.id;
        }
      })

      this.productsService.GetProductByID(this.productId).subscribe({
        next: (data) => {
          console.log(data.data)
          this.Product = data.data;
          this.tempPrice.push(this.Product.price);
        },
        error: (erorr: string) => this.ErrorMessage = erorr
      }),

      this.ReviewForm = this.fb.group(
        {
          reviewText: this.fb.control(''),
          date: this.fb.control(new Date().toISOString()),
          customerId: this.fb.control(this.customerIdetifier),
          productID: this.fb.control(this.productId)
        }
      ),
      this.reviewServise.GetReviews(this.productId).subscribe({
        next:data=>{
          this.ReviewsByProductId=data.data
        }
      }),
      this.Products.forEach((a:IProduct) => {
        Object.assign(a,{quantity: 1,total:a.price})
      });
  }

  addToCart(product:IProduct){

     product.quantity=this.SelectQuantity;
     product.price=product.quantity*this.Product.price;
    this.cartService.AddToCartTest(product,this.customerID).subscribe(
      {
        next:()=>{console.log("succses");}
        ,
        error:()=>{console.log("errorro form APi");}

      }
    )
    ;
    console.log("customerID from  ADDTO CATert in ------"+this.customerID);
  }

  get reviewText() {
    return this.ReviewForm.get('reviewText');
  }
  get date() {
    return this.ReviewForm.get('date');
  }
  get customerId() {
    return this.ReviewForm.get('customerId');
  }
  get productID() {
    return this.ReviewForm.get('productID');
  }

  Data(){
    console.log(this.ReviewForm.value)
  }

  AddNewReview() {
    this.reviewServise.AddReview(this.ReviewForm.value).subscribe({
      next:data=>{
        console.log(data)
      }
    });
  }


 // tempObj:any[]=[];
  IncreaseTheValue(product:IProduct)
  {
    this.SelectQuantity=this.SelectQuantity+1;
   // this.tempObj.push({id:product.id,price:product.price,quantity:this.SelectQuantity});

    //product.price=product.price+(this.tempObj[0].price* 1);
    console.log("price "+product.price+" Select Value "+this.SelectQuantity);

  }
}
