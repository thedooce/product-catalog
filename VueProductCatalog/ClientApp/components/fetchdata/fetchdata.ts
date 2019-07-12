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

    mounted() {
        fetch('api/Product/Products')
            .then(response => response.json() as Promise<Product[]>)
            .then(data => {
                this.products = data;
            });
    }
}
