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

    mounted() {
        fetch('api/Product/Products')
            .then(response => response.json() as Promise<Product[]>) //Waits for response, turns data to json?
            .then(data => { //binds data to vue list of <Product>
                this.products = data;
            });
    }

    addNewProduct() {
        this.productsEditable = true;
    }

    saveNewProduct() {
        //Validate fields
        if (this.validateName() && this.validateQuantity()) {
            this.products.push(this.newProduct);
            this.newProduct = <Product>{};
            this.productsEditable = false;
        }
        
        //Call API to save in backend, use fetch
        //fetch('api/Product/AddNewProduct')

        //Handle the response
    }

    validateName() {
        if (this.newProduct.name !== "") {
            return true;
        }
        else {
            return false;
        }
    }

    validateQuantity() {
        if (this.newProduct.quantity >= 0) {
            return true;
        }
        else {
            return false;
        }
    }

    
}
