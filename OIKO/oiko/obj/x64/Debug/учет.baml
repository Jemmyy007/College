   M S B A M L   `   `   `  ����?  ;oiko, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:oikooiko  5   	       oiko.учет   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:oiko     5   	     � Title$  учет��5   	   $	��534��6   $	��698��6#    � 
ResizeMode$ NoResize=�6/    � WindowStartupLocation$ CenterScreen=�6E   .��5	      � $��	0,0,0,-16q�6   ���	#FFA48BFF.+�5
   
   �� $��Учет��6   $��Center=�6   $	��Top=�6<   $��18(�6T   
�������6b   �� 5   
   -   5        $��Добавить ��5      $
��Left=�6%   $��498,336,0,0q�6@   $	��Top=�6U   $��30��6m   $��80��6y   ���	#FF3733BD
�������6�   �� 5   
   -   5        $��Изменить��5      $
��Left=�6$   $��498,404,0,0q�6?   $	��Top=�6T   $��30��6l   $��80��6x   ���	#FF3733BD
�������6�   �� 5   
   -   5        $��Удалить��5      $
��Left=�6#   $��596,404,0,0q�6>   $	��Top=�6S   $��30��6k   $��80��6w   ���	#FF3733BD
�������6�   �� 5   
   -   5        $�� ��5      $
��Left=�6   $��	10,10,0,0q�67   $	��Top=�6J   $��40��6b   $��41��6n    J� RenderTransformOrigin$ 0.5,0.5&�6y   ���	#FFA48BFFz�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -179.717Q�6&   T� 5      5      ��5      �� 5       �� ImageSource$ /pngwing.com (3).png��6   5      �� 5   
   -   5         ��Name$ 	txtInsert��5      $
��Left=�6%   $��111,336,0,0q�6@    �� TextWrapping$
 Wrap=�6U   $	��Top=�6i   $	��228��6�   $��30��6�   $��14(�6�   �� 5   
   -   5        $ 	txtUpdate��5      $
��Left=�6%   $��211,404,0,0q�6@   $
 Wrap=�6U   $	��Top=�6i   $	��128��6�   $��30��6�   $��14(�6�   �� 5   
   -   5        $ txtUP��5      $
��Left=�6!   $��111,403,0,0q�6<   $
 Wrap=�6Q   $	��Top=�6e   $��70��6}   $��30��6�   $��14(�6�   6�   �� 5   
   -   5        $��Печать��5      $
��Left=�6"   $��596,464,0,0q�6=   $	��Top=�6R   $��30��6j   $��80��6v   $ 0.531,0.109&�6�   ���	#FF3733BD
�������6�   &   System.Windows.Controls.DataGrid  5   
   -	   5          Name$ 	GridUchet��5      $��84,106,52,214q�6S   �� 5    
   -
   5        	 ��Name$	 	comStatus��5       $
��Left=�6&   $��355,336,0,0q�6A   $	��Top=�6V   $	��120��6n   
 �� 
IsReadOnly
 . .@�5!      �� $��На складе��6   �� 5"      $��Используется��6   �� 5#      $��Неисправно��6   5$      �� 5%   
   -   5        $	 
comStatus2��5%      $
��Left=�6'   $��355,402,0,0q�6B   $	��Top=�6W   $	��120��6o   
 . .@�5&      �� $��На складе��6   �� 5'      $��Используется��6   �� 5(      $��Неисправно��6   5)      �� 5*   
   $��Введите код��6   $
��Left=�6&   $��
34,403,0,0q�6A   $	��Top=�6U   $ 0.547,0.993&�6m   
�������6�   �� 5+   
   -   5        $��Все��5+      $
��Left=�6   $��
172,73,0,0q�6:   $	��Top=�6N   $��43��6}   ���	#FF3733BD
�������$��28��6�   �� 5,   
   -   5        $��На складе��5,      $
��Left=�6%   $��
225,73,0,0q�6@   $	��Top=�6T   $��77��6�   ���	#FF3733BD
�������$��28��6�   �� 5-   
   -   5        $��Используеся��5-      $
��Left=�6'   $��
325,73,0,0q�6B   $	��Top=�6V   $��90��6�   ���	#FF3733BD
�������$��28��6�   �� 5.   
   -   5        $��Неисправно��5.      $
��Left=�6&   $��
436,73,0,0q�6A   $	��Top=�6U   $��92��6�   ���	#FF3733BD
�������$��28��6�   �� 5/   
   -   5        $ 	txtSearch��5/      $
��Left=�6%   $��
154,50,0,0q�6@   $
 Wrap=�6T   $	��Top=�6h   $	��413��6�   6�   �� 50   
   $��Поиск:��6   $
��Left=�6!   $��
107,46,0,0q�6<   $	��Top=�6P   
�������6h   �� 51   
   $��V 1.5.2��6   $
��Left=�6"   $��
27,468,0,0q�6=   $	��Top=�6Q   
�������$ 
0.419,1.35&�6|   53      54      