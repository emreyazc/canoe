# canoe

##### What's a canoe?

canoe (\kə-ˈnü\) - a long narrow boat that is pointed at both ends and that is moved by a paddle with one blade

...but in this repository its a K-map solver made in C#.

#### What's a K-map
A K-map, also known as Karnaugh Map,  is a method to solve boolean functions quicker by turning a truth table into a 2D grid with binary co-ordinates. Here is how a 4-bit K-map looks:

![alt text](https://upload.wikimedia.org/wikipedia/commons/6/62/K-map_4x4_empty.svg "4-bit K-map")

To learn more about K-map's and solving boolean functions check out the [wiki](https://en.wikipedia.org/wiki/Karnaugh_map).

#### Canoe Features
In the current iteration of canoe, I have implemented a way to generate a K-map from a boolean function with the use of [Dijkstra's Shunting-yard algorithm.](https://en.wikipedia.org/wiki/Shunting-yard_algorithm) An implementation of the Shunting-yard algorithm can be seen in my repository called [shard](http://github.com/tarellano/shard). 

The next step for canoe is adding input through the K-map graphic.
