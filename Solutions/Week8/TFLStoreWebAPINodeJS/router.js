
var flowersController=require('./controllers/flowerscontroller');
var shoppingCartController=require('./controllers/shoppingcartcontroller');
const productsController = require('./controllers/productscontroller');

module.exports=function(app){
   // map  product catalog handlers with  REST request types

   app.route('/products')
      .get(productsController.getAllProducts)
      .post(productsController.createProduct);
      
      app.route('/products/:id')
      .get( productsController.getProductById)
      .put(productsController.updateProduct)
      .delete(productsController.deleteProduct);

    app.route('/flowers')
       .get(flowersController.getAll)
       .post(flowersController.insert);
    app.route('/flowers/:flowerid')
       .put(flowersController.update)
       .get(flowersController.getById)
       .delete(flowersController.delete);

    // map  shoppingcart  handlers with  REST request types
  
    app.route('/cart')
       .get(shoppingCartController.get)
       .post(shoppingCartController.post);
    app.route('/cart/:itemid')
       .put(shoppingCartController.put)
       .get(shoppingCartController.getById)
       .delete(shoppingCartController.delete);
};

