   M S B A M L   `   `   `  ����R  N22_NguyenThaiThinh_Ass1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:_22_NguyenThaiThinh_Ass1_22_NguyenThaiThinh_Ass1  5   	   +    %_22_NguyenThaiThinh_Ass1.AdminProduct   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:_22_NguyenThaiThinh_Ass1     5   	     � Title$  22_NguyenThaiThinh_Lab1��5   	   $	��800��5	   	   $	��600��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �� $	��Top=�6   .+�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $��3* �6$   �� 5      $��* �6$   .+�5      ��  �� Orientation$ Vertical=�6   $
��Left=�5      $��	405,0,0,0q�5      $	��375��5      .+�5      �� -   5        $
��Back��5      $
��Left=�5      $��10q�5      $��80��5      $	��Top=�5      �� 5      $��Search��6   �� 5       $��Product Name��6   �� 5!      -   5        $��
SearchName��5!      5"      �� 5#      $��Product Price��6   �� 5$      -   5        $��SearchPrice��5$      5%      �� 5&      $��
Product ID��6   �� 5'      -   5        $��SearchId��5'      5(      �� 5)      $��Product in Stock��6   �� 5*      -   5        $��SearchUnitInStock��5*      5+      �� 5,      $��Range Price��6   �� 5.      -   5         ��Name$ MinPrice��5.      $��5q�50      �� 51      -   5        $ MaxPrice��51      $��5q�53      54      �� 55      
����ح�$ Vertical=�56      $
��Left=�57      $	��400��58      .+�59      �� -   5        $��lbTitle��59      
���  ��$��DemiBold"�5;      $��20(�5<      $��Product Information��5=      �� 5>      -	   5        $��lbProductId��5>      $��
Product Id��5?      �� 5@      -
   5        $��txtProductId��5@      $��Stretch=�5A      $��25��5B      ��5C      ��  �� Path$ 	ProductId� �� Mode$ OneWay=� � DataContext 5D      ��  �� ElementName$ 
lvProducts��$ SelectedItem��� 5F      -   5        $��lbCategoryId��5F      $��
CategoryId��5G      �� 5H      -   5        $��txtCategoryId��5H      $��Stretch=�5I      $��25��5J      ��5K      �� $ 
CategoryId�$ TwoWay=� 5L      �� $ 
lvProducts��$ SelectedItem��� 5N      -   5        $��	CateItems��5Q      	 �� DisplayMemberPath$	 CategoryName��5O      
 �� SelectedValuePath$
 
CategoryId��5P       �� 
IsReadOnly$
 True��5S   <    �� SelectedValue 5R      �� $ 
CategoryId�$ TwoWay=�5S   <   �� 5T      -   5        $��lbProductName��5T      $��Product Name��5U      �� 5V      -   5        $��txtProductName��5V      $��Stretch=�5W      $��25��5X      ��5Y      �� $ ProductName�$ OneWay=� 5Z      �� $ 
lvProducts��$ SelectedItem��� 5\      -   5        $��lbWeight��5\      $��Weight��5]      �� 5^      -   5        $��	txtWeight��5^      $��Stretch=�5_      $��25��5`      ��5a      �� $ Weight� �� StringFormat$ {0:N3}��$ OneWay=� 5c      �� $ 
lvProducts��$ SelectedItem��� 5e      -   5        $��lbUnitPrice��5e      $��
Unit Price��5f      �� 5g      -   5        $��txtUnitPrice��5g      $��Stretch=�5h      $��25��5i      ��5j      �� $ 	UnitPrice�$ OneWay=� 5k      �� $ 
lvProducts��$ SelectedItem��� 5m      -   5        $��lbUnitInStock��5m      $��Unit In Stock��5n      �� 5o      -   5        $��txtUnitInStock��5o      $��Stretch=�5p      $��25��5q      ��5r      �� $ UnitInStock�$ OneWay=� 5s      �� $ 
lvProducts��$ SelectedItem�5u      �� 5v      $��1��6   $ 
Horizontal=�5w      $
��Left=�5x      .+�5y      �� -   5         ��Name$ btnLoad��5y      $��10q�5z      $��80��5{      $
��Load��5|      5}      �� 5~      -   5        $ 	btnInsert��5~      $��10q�5      $��80��5�      $��Insert��5�      5�      �� 5�      -   5        $ 	btnUpdate��5�      $��10q�5�      $��80��5�      $��Update��5�      5�      �� 5�      -   5        $ 	btnDelete��5�      $��10q�5�      $��80��5�      $��Delete��5�      5�      5�      �� 5�      -   5        $��
lvProducts��5�      $��2��5�      $
��Auto��5�      $
��Auto��5�       �� View 5�      �� 5�      .P�5�      �� $��
Product ID��6-    �� Width$	 100��5�   -    �� DisplayMemberBinding 5�   -   �� $ 	ProductId��� 5�      $��
CategoryId��6-   $	 100��5�   -    5�   -   �� $ 
CategoryId��� 5�      $��Product Name��6-   $	 200��5�   -    5�   -   �� $ ProductName��� 5�      $��Weight��6-   $	 100��5�   -    5�   -   �� $ Weight��� 5�      $��	UnitPrice��6-   $	 100��5�   -    5�   -   �� $ 	UnitPrice��� 5�      $��Unit In Stock��6-   $	 200��5�   -    5�   -   �� $ UnitInStock�5�      5�      5�      5�      5�      5�      