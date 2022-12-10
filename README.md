# magiceden-ML
API for NFT price prediction on Magic Eden using Machine Learning, the ideia is have  im minimal top 10 nft in the marketplace,we currently have one trained model.

Y00ts
Pricision: 0,9(90%)\
Mode: FastTreeTweedieRegression with 6835 row of csv data in model trained.
### Run the docker with Api that uses trained model.
```bash 
docker compose up
```
https://localhost:{port}/swagger/index.html\
in Collection , write y00ts and choose some mintAddrea address, API will get the metadata using magic eden api and pass to machine learning to retrieve price suggestions.
### Result example.
```json 
{
  "owner": "6oeLkowpnJN6PztxXU2GzCKQKNZeRQ9RscUv6PDc5G7q",
  "supply": 1,
  "delegate": null,
  "collection": "y00ts",
  "name": "y00t #6519",
  "updateAuthority": "yootn8Kf22CQczC732psp7qEqxwPGSDQCFZHkzoXp25",
  "primarySaleHappened": true,
  "sellerFeeBasisPoints": 333,
  "image": "https://metadata.y00ts.com/y/6518.png",
  "attributes": [...],
  "properties": {...},
  "price": [
    182.41739,
    165.83398,
    149.25058
  ]
}
```
![Captura da Web_10-12-2022_243_localhost_1](https://user-images.githubusercontent.com/52639395/206830586-24063ae4-ba7e-45d2-8ba1-320d337eeb22.jpeg)
