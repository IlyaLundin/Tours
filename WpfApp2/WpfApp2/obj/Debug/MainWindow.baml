   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$.  (Тур агентство Лундина��5   	   $	��680��6'   $	��680��67   $
��1350��6D   $
��1350��6T    � Topmost .  � WindowStartupLocation$ CenterScreen=�6p   .��5	      �  � RowDefinitions 5   
   �� 5      $��70 �6   6*   �� 5      $��5* �6   6*   �� 5      $��50 �6   6*   .+�5   
   � $��0��6   ���#bae3e8.+�5      �� $!��Resource/логотип.png��6   $
��Left=�62   $��5q�6M   �� 5      $.��(Тур агентство Лундина��6      TextBlockMain#��[  65   5      � 5   
   $��2��6   ���#445c9363   �� 5   
   $��Comic Sans MS)�6   $��15(�6/   $��3��6=    �� TextAlignment$
 Left=�6J    �� Padding$ 10q�6_   �� 5   
   -   5        $��BtnExit��5      $��2��6    $��
Выйти��6-     
ButtonMain#��[ 6=   $
��Left=�6w   �� 5   
   -   5        $��UserName��5      $	��400��6$   $��40��60   
�������$��0��6O   $��Right=�6\   $��10q�6x   $��Comic Sans MS)�6�   $��20(�6�   $ Center=�6�    � 5   
   -   5        $��	MainFrame��5      $��1��6     � NavigationUIVisibility$ Hidden=�6Z   6|   �� 5   
   -   5        $��BtnBack��5   b   $��
Назад��6   #��[ 6"   $��Right=�6F   $��2��6�   �� 5   
   -   5        $��BtnWatchHotels��5      #��[ 6'   $��15(�6K   $��Center=�6Y   $'��!Просмотреть отели��6v   $��2��6�   $y�Hidden=�6�   5      5      