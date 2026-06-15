import java.util.*;

public class Main {

    public static int linearSearch(Product products[], int key) {

        for(int i = 0; i < products.length; i++) {

            if(products[i].productId == key) {
                return i;
            }
        }

        return -1;
    }

    public static int binarySearch(Product products[], int key) {

        int l = 0;
        int r = products.length - 1;

        while(l <= r) {

            int mid = (l + r) / 2;

            if(products[mid].productId == key) {
                return mid;
            }

            if(products[mid].productId < key) {
                l = mid + 1;
            }
            else {
                r = mid - 1;
            }
        }

        return -1;
    }

    public static void main(String[] args) {

        Product products[] = {
            new Product(101, "Laptop", "Electronics"),
            new Product(102, "Mobile", "Electronics"),
            new Product(103, "Shoes", "Fashion"),
            new Product(104, "Watch", "Accessories"),
            new Product(105, "Bag", "Fashion")
        };

        int key = 104;

        int linearResult = linearSearch(products, key);

        if(linearResult != -1) {
            System.out.println("Linear Search Found: "
                    + products[linearResult].productName);
        }
        else {
            System.out.println("Product Not Found");
        }

        int binaryResult = binarySearch(products, key);

        if(binaryResult != -1) {
            System.out.println("Binary Search Found: "
                    + products[binaryResult].productName);
        }
        else {
            System.out.println("Product Not Found");
        }
    }
}