   M S B A M L   `   `   `  ����@  <Chess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Chess.View
Chess.View  5          Chess.View.Game   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Chess.View     5      -   5          N� Title$
  Game��5	       � 	Resources 5
       �� 
TargetType   NotEven �� Property �� Value  Even  Time  UsersButton  UsersButton2  NameAndTimer  CheckAndMate��%O  &	        &	 q     &	 �     &	 u    &	 R    &	 -    &	 �    �� 5   
   " ��6   .�5      ��  � �� �#9acdcd6+   �� 5       � ��$ 0q�60   5      �� 5   
   " ��6   .�5      ��  � �� �#ffffff6+   �� 5       � ��$ 0q�60   5      �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 30(�6)   �� 5       � ��$	 225��6)   5      �� 5   
   " ��6   .�5      ��  � ��$	 225��6)   �� 5       � ��$ 0q�60   �� 5       � �� �#9acdcd6+   �� 5       � ��$ 30(�6)   �� 5       � ��$ 5q�6(   5      �� 5   
   " ��6   .�5       ��  � ��$	 225��6)   �� 5!       � ��$ 0q�60   �� 5"       � �� �#ffff6+   �� 5#       � ��$ 5q�6(   �� 5$       � ��$ 30(�6)   5%      �� 5'   
   " ��6   .�5(      ��  � ��$ 30(�6)   �� 5)       � ��
 �����6+   5*      �� 5+   
   " ��6   .�5,      ��  � ��$ 25(�6)   �� 5-       � ��
 �  ��6+   5.      5/      .��50      � 
���   � � RowDefinitions 51   
   �� 52      �� 53      $��5* �6   �� 54      �� 55      $
��0.8* �6   .+�58   
   � -   5         �Name$ 	GridBoard��58      $��3q�6"   $��1��6-   ��6|   �� *ActualHeight+ �� RelativeSource �� *Self+ � ColumnDefinitions 59      �� 5:      �� 5;      �� 5<      �� 5=      �� 5>      �� 5?      �� 5@      �� 5A       5C      �� 5D      �� 5E      �� 5F      �� 5G      �� 5H      �� 5I      �� 5J      �� 5K      5M      �� 5O   
   -   5        	 ��Name$	 textBlockStatus��5O      #��[ 6-   $��1��6S   $��0��6`   $��Center=�6p   $��5q�6�   $��Right=�6�   �� 5P   
   
 �� Orientation$
 
Horizontal=�6   $��Center=�6.   $��Center=�6I   $��0��6f   .+�5Q      �� -   5        $
��usN1��5Q   >   #��[ 6   6>   5R      �� 5S   
   $
 
Horizontal=�6   $��Center=�6.   $��Center=�6I   $��2��6f   .+�5T      �� -   5        $
��usN2��5T   >   #��[ 6   6>   5U      �� 5V   
   $
 
Horizontal=�6   $��3��6.   .+�5W      �� -   5        $��LiveTimeLabel��5W   2   #��[ 6   $��%TIME%��6G   
�������6X   �� 5X      -   5        #��[ 5X      $%��Сохранить партию��6:   6U   �� 5Y      -   5        #��[ 5Y      $%��Загрузить партию��6;   6V   �� 5Z      #��[ 6   $
��Home��6<   ��6T   ��  �� Path$ 
SelectPage�.��5[      �� $*��$D:\COURSE_PROJECT\Images\Leaving.png��6   5\      5]      5^      5_      