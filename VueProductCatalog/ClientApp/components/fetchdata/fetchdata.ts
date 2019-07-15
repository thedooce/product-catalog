import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface Product {
    name: string;
    quantity: number;
    description: string;
}

@Component
export default class FetchDataComponent extends Vue {
    products: Product[] = [];
    productsEditable: boolean = false;
    newProduct: Product = <Product>{};
    nameValid: boolean = true;
    quantityValid: boolean = true;
    serverError: boolean = false;
    saveSuccess: boolean = false;

    mounted() {
        fetch('api/Product/Products')
            .then(response => response.json() as Promise<Product[]>) //Waits for response, turns data to json?
            .then(data => { //binds data to vue list of <Product>
                this.products = data;
            });
    }

    addNewProduct() {
        this.productsEditable = true;
        this.serverError = false;
        this.saveSuccess = false;
    }

    validateName() {
        if (this.newProduct.name && this.newProduct.name !== "") {
            this.nameValid = true;
        }
        else {
            this.nameValid = false;
        }
    }

    validateQuantity() {
        if (this.newProduct.quantity > 0) {
            this.quantityValid = true;
        }
        else {
            this.quantityValid = false;
        }
    }

    saveNewProduct() {
        //Validate fields
        this.validateName();
        this.validateQuantity();
        if (this.nameValid && this.quantityValid) {
            this.products.push(this.newProduct);
            this.productsEditable = false;

            var data = JSON.stringify(this.newProduct);
            console.log(data)

            fetch('api/Product/AddNewProduct', {
                method: 'POST',
                body: data,
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(res => res.json())
                .then(response => this.saveSuccess = true)
                .catch (error => this.serverError = true);
                //.then(response => console.log('Success:', JSON.stringify(response)))
                //.catch(error => console.error('Error:', error)); //Change console.Error to turn on the Error item, just like the warning for no items found!


        //Handle the response

            //At the end, blank it out!
            this.newProduct = <Product>{};

        }
    }

   

    
}
